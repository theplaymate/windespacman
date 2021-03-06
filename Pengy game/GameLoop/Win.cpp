#include "Win.h"
#include <tchar.h>
//////////////////////////////////////////////////////////////////
// Static Initialisation
//////////////////////////////////////////////////////////////////
static CWin * g_pCWin		= NULL;
HINSTANCE CWin::m_hInstance = GetModuleHandle(NULL);

//////////////////////////////////////////////////////////////////
// Connectivity WIN32 -> Class
//////////////////////////////////////////////////////////////////
LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	return g_pCWin->MsgProc(hWnd, uMsg, wParam, lParam);
}

//////////////////////////////////////////////////////////////////
// Constructors/Destructors
//////////////////////////////////////////////////////////////////
CWin::CWin()
{
	g_pCWin		 = this;

	this->m_hWnd = NULL;
	this->m_dwCreationFlags		= 0L;
	this->m_dwWindowStyle		= (WS_OVERLAPPEDWINDOW | WS_SYSMENU) & ~(WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_THICKFRAME) ;
	this->m_dwExWindowStyle		= WS_EX_OVERLAPPEDWINDOW;
	this->m_dwCreationFlags		= SW_SHOW;
	this->m_PosX				= CW_USEDEFAULT;	
	this->m_PosY				= CW_USEDEFAULT;	
	this->m_dwCreationWidth		= 800;
	this->m_dwCreationHeight	= 600;
	
	this->m_hbrWindowColor		= (HBRUSH)(COLOR_WINDOW+1);
	this->m_hIcon				= LoadIcon(m_hInstance, (LPCTSTR)IDI_APPLICATION);
	this->m_strWindowTitle		= _T("Kovu the Pinguin");
	this->m_hMenu				= NULL; 	
	this->positionX = 50;
	this->positionY = 300;
	this->jump=0;
	this->jump_speed=-20;
	this->gravity=1;
	this->direction=0;
	this->pinguin = 0;
}

CWin::~CWin()
{
}


//////////////////////////////////////////////////////////////////
// Functions
//////////////////////////////////////////////////////////////////
int CWin::Run()
{
	MSG msg;

	ZeroMemory( &msg, sizeof(msg) );
	
	while( msg.message!=WM_QUIT )
	{
		if( PeekMessage( &msg, NULL, 0U, 0U, PM_REMOVE ) )
		{
			TranslateMessage( &msg );
			DispatchMessage( &msg );
		} 
		else 
		{
		  GameLoop(m_hWnd);
		}
	}
	
	GameEnd();
	
	return msg.wParam;
}

HRESULT CWin::Create()
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX); 

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= (WNDPROC)WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= m_hInstance;
	wcex.hIcon			= m_hIcon;
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= m_hbrWindowColor;
	wcex.lpszMenuName	= NULL;
	wcex.lpszClassName	= _T("Skeleton");
	wcex.hIconSm		= NULL;

	::RegisterClassEx(&wcex);

	m_hWnd = ::CreateWindowEx(m_dwExWindowStyle,_T("Skeleton"), m_strWindowTitle, m_dwWindowStyle,
	  m_PosX, m_PosY, m_dwCreationWidth, m_dwCreationHeight, NULL, m_hMenu, m_hInstance, NULL);

	if (!m_hWnd)
	{
	  return FALSE;
	}

	graphics = ::GetDC(m_hWnd);
	GameInit();

	::ShowWindow(m_hWnd, m_dwCreationFlags);
	::UpdateWindow(m_hWnd);

	return TRUE;

}

LRESULT CWin::MsgProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	int wmId;
	int wmEvent;
	
	if (!m_hWnd)
		m_hWnd = hWnd;

	switch (uMsg) 
	{
		case WM_CREATE:
			graphics = ::GetDC(hWnd);
			ShowWindow(hWnd, SW_SHOWDEFAULT);
		break;
		case WM_COMMAND:
			wmId    = LOWORD(wParam); 
			wmEvent = HIWORD(wParam); 
			break;
		case WM_ERASEBKGND:
			return 1;
		break;
		case WM_DESTROY:
			PostQuitMessage(0);
			break;
		case WM_KEYDOWN:
			if(pinguin == 0)
			{
				pinguin = 1;
			}
			else if(pinguin == 1)
			{
				pinguin = 0;
			}
			if( GetAsyncKeyState(VK_LEFT))
			{
				this->positionX += -10;direction=1;
			}
			else if( GetAsyncKeyState(VK_RIGHT))
			{
				this->positionX+=10;direction=0;
			}
			else if(GetAsyncKeyState(VK_UP))
			{
				this->positionY+=-10;
			}
			else if(GetAsyncKeyState(VK_DOWN))
			{
				this->positionY+=10;
			}
			else if(GetAsyncKeyState(VK_SPACE))
			{
				if(jump==0)
				{
					this->jump=1;
				}
			}
		break;
		default:
			return DefWindowProc(hWnd, uMsg, wParam, lParam);
   }
   return 0;
}
