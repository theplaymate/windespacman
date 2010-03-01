#pragma once
#include "Observer.h"
#include "MessageQueue.h"
#include "LevelView.h"
#include "Tile.h"
#include "Surface.h"


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
	vector<Surface> * surfaces;
    static Level* pInstance;
	LevelView levelView;
	vector<int*> GetLevel1Tiles();
	vector<int*> GetLevel1Surfaces();
	int levelLength;
	void SetLevelLength();
};
