#include "Skeleton.h"
//#include "Bitmap.h"
//#include "Messages.h"
#include "Location.h"
#include "Gadget.h"
#include "SPLASH.h"
#include "resource.h"
#include "Waldo.h"
using namespace dotnetguy;


/////////////////////////////////////
// Constructors / Destructors      //
/////////////////////////////////////
CSkeleton::CSkeleton()
{

}

CSkeleton::~CSkeleton()
{
}

/////////////////////////////////////
// Member functions                  //
/////////////////////////////////////

LRESULT CSkeleton::MsgProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	Waldo * waldo;
	SPLASH splash;
	Location * location;
	switch (uMsg) 
	{
	case WM_CREATE:
		splash.Init(hWnd, this->m_hInstance, IDB_BITMAP2 );
		splash.Show();
		Sleep(3000);
		splash.Hide();
		
		location = new Location();
		location->X = 200;
		location->Y = 300;
		waldo = new Waldo(location);
		
		messageQueue->Inst()->attach(level->Inst());
		messageQueue->Inst()->attach(character->Instance());
		messageQueue->Inst()->attach(renderer->Inst());
		messageQueue->Inst()->attach(sound->Inst());
		messageQueue->Inst()->attach(new GadgetFactory());
		messageQueue->Inst()->attach(waldo);
		messageQueue->Inst()->attach(world->Inst());
		break;
	case WM_KEYDOWN:
		switch(wParam)
		{
		case 32:
			messageQueue->Inst()->sendMessage(CM_CHARACTER_SPACEBAR, NULL, NULL);
			break;
		case 37:
			messageQueue->Inst()->sendMessage(CM_CHARACTER_LEFT, NULL, NULL);
			break;
		case 38:
			messageQueue->Inst()->sendMessage(CM_CHARACTER_UP, NULL, NULL);
			break;
		case 39:
			messageQueue->Inst()->sendMessage(CM_CHARACTER_RIGHT, NULL, NULL);
			break;
		case 40:
			messageQueue->Inst()->sendMessage(CM_CHARACTER_DOWN, NULL, NULL);
			break;

		case 't':
		case 'T':
			messageQueue->Inst()->sendMessage(CM_CHARACTER_RESET_POSITION, NULL, 10);
			break;

		case 'r':
		case 'R':
			messageQueue->Inst()->sendMessage(CM_CHARACTER_RESET_POSITION, 50, 200);
			break;
		
		case 'g':
		case 'G':
			MessageQueue::Inst()->sendMessage(CM_SOUND_EVENT,(WPARAM)(LPCTSTR)"res/pengy.wav", 0);
			break;

			// show the fps
		case 'f':
		case 'F':
			if(Renderer::ShowFps)
				Renderer::ShowFps = false;
			else
				Renderer::ShowFps = true;
			break;

			// show the surfaces
		case 's':
		case 'S':
			if(Renderer::ShowSurfaces)
				Renderer::ShowSurfaces = false;
			else
				Renderer::ShowSurfaces = true;
			break;

			// show the debug
		case 'd':
		case 'D':
			if(Renderer::ShowDebug)
				Renderer::ShowDebug = false;
			else
				Renderer::ShowDebug = true;
			break;
		}
		break;
	}
	return CWin::MsgProc(hWnd, uMsg, wParam, lParam);
}

void CSkeleton::GameInit()
{
	messageQueue->Inst()->sendMessage(CM_LEVEL_START, NULL, NULL);

	RECT rect;
	rect.left = 0;
	rect.top = 0;
	rect.right = 800;
	rect.bottom = 600;

	bufDC = CreateCompatibleDC(graphics);
	HBITMAP bufBMP;
	bufBMP = CreateCompatibleBitmap(graphics, 800, 600);
	SelectObject(bufDC, bufBMP);
	::FillRect(bufDC, &rect, ::CreateSolidBrush(0x00FFFFFF));

	SYSTEMTIME systemTime;
	GetSystemTime( &systemTime );

	FILETIME fileTime;
	SystemTimeToFileTime( &systemTime, &fileTime );

	ULARGE_INTEGER uli;
	uli.LowPart = fileTime.dwLowDateTime;
	uli.HighPart = fileTime.dwHighDateTime;

	ULONGLONG systemTimeIn_ms( uli.QuadPart/10000 );
	previousUpdateTime = systemTimeIn_ms;
}

void CSkeleton::GameLoop()
{
	Update();
	Render(this->m_hWnd);
}

void CSkeleton::GameEnd()
{

}

void CSkeleton::Render(HWND hWnd)
{
	RECT rect;
	rect.left = 0;
	rect.top = 0;
	rect.right = 800;
	rect.bottom = 600;

	//::FillRect(bufDC, &rect, ::CreateSolidBrush(RGB(200, 255, 255)));
	renderer->Inst()->render(bufDC);
	BitBlt(graphics, 0,0, 800, 600,bufDC, 0, 0, SRCCOPY);
}

void CSkeleton::Update()
{
	SYSTEMTIME systemTime;
	GetSystemTime( &systemTime );

	FILETIME fileTime;
	SystemTimeToFileTime( &systemTime, &fileTime );

	ULARGE_INTEGER uli;
	uli.LowPart = fileTime.dwLowDateTime;
	uli.HighPart = fileTime.dwHighDateTime;

	ULONGLONG systemTimeIn_ms( uli.QuadPart/10000 );
	int elapsedTime = (int)(systemTimeIn_ms - previousUpdateTime);

	messageQueue->Inst()->sendMessage(CM_UPDATE, elapsedTime, NULL);
	previousUpdateTime = systemTimeIn_ms;
}