#pragma once
#include "Win.h"
class Gadget;

class GadgetState;

class GadgetStateMachine
{
public:
	GadgetStateMachine(void);
	GadgetStateMachine(Gadget * gadget);
	~GadgetStateMachine(void);

	GadgetState * pAvailable;
	GadgetState * pPickedUp;

	void Update(int timeElapsed);
	void ReceiveMessage(UINT message, WPARAM wParam, LPARAM lParam);
	void Transition(GadgetState * pGadgetState);

private:
	GadgetState * pCurrentState;
};
