#pragma once
#include "Surface.h"
#include "Observer.h"
#include "MessageQueue.h"
#include "LevelView.h"
#include "Location.h"


class Level : public Observer
{
public:
	static Level* Inst();
    ~Level();
    void recieveMessage(UINT message, WPARAM wParam, LPARAM lParam);
	void LoadLevel(int level);
protected:
	Level();
private:
	vector<Surface*> * surfaces;
    static Level* pInstance;
	LevelView levelView;
	vector<int*> GetLevel1Tiles();
	vector<int*> GetLevel1Surfaces();
	int levelLength;
	void SetLevelLength();
	bool LocationInSurfaceX(Location * location, Surface * surface);
	bool LocationInSurfaceY(Location * location, Surface * surface);
};
