#include "Level.h"
#include "Location.h"
#include "Math.h"
#include "Waldo.h"
#include "LevelIntro.h"
#include "Skeleton.h"

Level* Level::pInstance = NULL;

Level* Level::Instance(){
  if(pInstance == NULL){
    pInstance = new Level();
  }
  return pInstance;
}

Level::Level()
{ 
	levelRunning = false;
	currentLevel = new BeachLevel();
}

void Level::SetLevelLength()
{
	int maxX = 0;
	vector<Surface*>::iterator iterator = surfaces.begin();
	while(iterator != surfaces.end())
	{
		Surface * pSurface = *iterator;
		if(maxX < pSurface->xTo)
		{
			maxX = pSurface->xTo;
		}
		iterator++;
	}
	levelLength = maxX;
}

Level::~Level(){
  if(pInstance != 0)delete pInstance;
}

void Level::ReceiveMessage(UINT message, WPARAM wParam, LPARAM lParam) 
{
	switch (message) 
	{
	case CM_KEY:
		break;
	case CM_LEVEL_LOAD:
		LoadLevel(pWorld->Instance()->level);
		MessageQueue::Instance()->SendMessage(CM_LEVEL_LENGTH, levelLength, NULL);
		break;
	case CM_CHARACTER_MOVE_X_FROM_TO:
		if(physic_behavior.MoveXFromTo((Location*)wParam,(Location*)lParam,surfaces)==true)
			MessageQueue::Instance()->SendMessage(CM_CHARACTER_BUMPS_INTO, (int)physic_behavior.pSurfaceFinal, NULL);
		break;

	case CM_CHARACTER_FALL_Y_FROM_TO:
		if(physic_behavior.FallYFromTo((Location*)wParam,(Location*)lParam,surfaces)==false)
			MessageQueue::Instance()->SendMessage(CM_CHARACTER_IS_FALLING, NULL, NULL);
		else
			MessageQueue::Instance()->SendMessage(CM_CHARACTER_IS_STANDING, (int)physic_behavior.pOnSurfaceFinalFall,(int)currentLevel->pSlopes);
		break;

	case CM_CHARACTER_JUMP_Y_FROM_TO:
		if(physic_behavior.JumpYFromTo((Location*)wParam,(Location*)lParam,surfaces)==true)
			MessageQueue::Instance()->SendMessage(CM_CHARACTER_JUMPING_BUMPS_HEAD, (int)physic_behavior.pOnSurfaceFinalJump, NULL);
		break;
	case CM_GAME_START:
		levelView.StartGame();
		//MessageQueue::Instance()->SendMessage(CM_LEVEL_BEGIN, NULL, NULL);
		break;
	case CM_WINTERLEVEL_OPEN_BRIDGE:
		this->surfaces[0]->isSurfaceOfDeath = false;
		break;
	}
}

void Level::LoadLevel(int level)
{
	CSkeleton::paused = true;
	levelRunning = false;
	vector<Tile> myTiles;
	vector<int*> data;
	LPCSTR path = "";
	LevelIntro * levelIntro;
	switch(level)
	{
	case 1:
		delete currentLevel;
		levelIntro = new LevelIntro("res/IntroSummer.bmp", "res/IntroSummerInfo.bmp", 2000, 4000);
		MessageQueue::Instance()->SendMessage(CM_SOUND_LOOP, (WPARAM)(LPCTSTR)"res/Waves/1_beach.wav", NULL);
		currentLevel = new BeachLevel();
		path = "res/tilemap.bmp";
		data = currentLevel->GetTiles();
		surfaces = currentLevel->GetSurfaces();
		currentLevel->LoadGadgets();
		currentLevel->LoadEnemies();
		SetLevelLength();
		break;
	case 2:
		delete currentLevel;
		levelIntro = new LevelIntro("res/IntroForest.bmp", "res/IntroForestInfo.bmp", 2000, 4000);
		MessageQueue::Instance()->SendMessage(CM_SOUND_LOOP, (WPARAM)(LPCTSTR)"res/Waves/3_forest.wav", NULL);
		currentLevel = new ForestLevel();
		path = "res/tilemap_forest.bmp";
		data = currentLevel->GetTiles();
		surfaces = currentLevel->GetSurfaces();
		currentLevel->LoadGadgets();
		currentLevel->LoadEnemies();
		SetLevelLength();
		break;
	case 3:
		delete currentLevel;
		levelIntro = new LevelIntro("res/IntroWinter.bmp", "res/IntroWinterInfo.bmp", 2000, 4000);
		MessageQueue::Instance()->SendMessage(CM_SOUND_LOOP, (WPARAM)(LPCTSTR)"res/Waves/2_snow.wav", NULL);
		currentLevel = new SnowLevel();
		path = "res/tilemap.bmp";
		data = currentLevel->GetTiles();
		surfaces = currentLevel->GetSurfaces();
		currentLevel->LoadGadgets();
		currentLevel->LoadEnemies();
		SetLevelLength();
		break;
	default:
		//level1
		path = "res/tilemap.bmp";
		data = currentLevel->GetTiles();
		surfaces = currentLevel->GetSurfaces();
		currentLevel->LoadGadgets();
		currentLevel->LoadEnemies();
		SetLevelLength();
		break;
	}

	vector<int*>::iterator iterator = data.begin();
	while(iterator!=data.end())
	{
		int* dataRow = *iterator;
		if(dataRow[4] == 1)
			myTiles.push_back(Tile(dataRow[0], dataRow[1], dataRow[2], dataRow[3], true, dataRow[5]));
		else
			myTiles.push_back(Tile(dataRow[0], dataRow[1], dataRow[2], dataRow[3], false, dataRow[5]));

		iterator++;
	}
	
	levelView.SetSurface(&surfaces);
	levelView.SetTiles(myTiles, path);
	MessageQueue::Instance()->SendMessage(CM_PAUSE, NULL, NULL);
	levelRunning = true;
}

bool Level::GetLevelRunning()
{
	return levelRunning;
}