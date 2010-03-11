#ifndef Skeleton_H
#define Skeleton_H

#include "Win.h"
#include "Bitmap.h"
#include "Renderer.h"
#include "Character.h"
#include "Sound.h"
#include "Menu.h"
#include "GadgetFactory.h"
#include <sstream>
using namespace dotnetguy;

class CSkeleton : public CWin
{
public:
	CSkeleton();
	~CSkeleton();



	LRESULT MsgProc(HWND, UINT, WPARAM, LPARAM);
	void GameInit();
	void GameLoop();
	void GameEnd();
private:
	Character* character;
	Renderer* renderer;
	MessageQueue* messageQueue;
	Level* level;
	World* world;
	Menu* menu;
	Sound* sound;
	void Update();
	void Render(HWND);
	HDC bufDC;
	ULONGLONG previousUpdateTime;
	bool paused;
};

#endif
