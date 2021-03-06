#pragma once
#include "Surface.h"
#include "Observer.h"
#include "MessageQueue.h"
#include "LevelView.h"
#include "Location.h"
#include "BeachLevel.h"d
#include "World.h"
#include "Physics.h"
#include "MovingSurface.h"
#include "SnowLevel.h"
#include "ForestLevel.h"

class Level : public Observer
{
public:
	static Level* Instance();
    ~Level();
    void ReceiveMessage(UINT message, WPARAM wParam, LPARAM lParam);
	void LoadLevel(int level);
	bool GetLevelRunning();
	vector<Surface*> surfaces;
protected:
	Level();
private:
	vector<MovingSurface*> movingSurfaces;
    static Level* pInstance;
	LevelView levelView;
	LevelData * currentLevel;
	Physics physic_behavior;
	int levelLength;
	void SetLevelLength();
	World* pWorld;
	bool levelRunning;
	
	/*bool LocationInSurfaceX(Location * location, Surface * surface);
	bool LocationInSurfaceY(Location * location, Surface * surface);*/
};
