#include "Idle.h"
#include "Walking.h"
#include "Jumping.h"
#include "CharacterStateMachine.h"

Idle::Idle(void)
{
	
}

Idle::Idle(CharacterStateMachine * pStateMachine) : CharacterState(pStateMachine)
{

}

void Idle::Up()
{

}

void Idle::Down()
{	
	this->pStateMachine->Transition(this->pStateMachine->pFalling);
}


void Idle::Left()
{
	this->pStateMachine->pWalking->Left();
	this->pStateMachine->Transition(this->pStateMachine->pWalking);
}


void Idle::Right()
{
	this->pStateMachine->pWalking->Right();
	this->pStateMachine->Transition(this->pStateMachine->pWalking);
}

void Idle::Throw()
{

}


void Idle::Spacebar()
{
	this->pStateMachine->pJumping->Spacebar();
	this->pStateMachine->Transition(this->pStateMachine->pJumping);
}

void Idle::Update(int timeElapsed)
{

}

void Idle::ReceiveMessage(UINT message, WPARAM wParam, LPARAM lParam)
{
	Surface * pOnSurface;
	switch(message)
	{
	case CM_CHARACTER_IS_FALLING:
		this->pStateMachine->Transition(this->pStateMachine->pFalling);
		break;
	case CM_CHARACTER_IS_STANDING:
		pOnSurface = (Surface*) wParam;
		if(pOnSurface->isSurfaceOfDeath)
		{
			MessageQueue::Instance()->SendMessage(CM_CHARACTER_KILLED, NULL, NULL);
			break;
		}
		if(pOnSurface->isSlope != 0)
		{
			MessageQueue::Instance()->SendMessage(CM_IS_SLOPING, lParam, NULL);
			break;
		}
		if(pOnSurface->isIce == true && Character::Instance()->hasSnowBoots == false)
		{
			MessageQueue::Instance()->SendMessage(CM_SOUND_EVENT,(WPARAM)(LPCTSTR)"res/Waves/smash.wav", 0);
			pStateMachine->pIceWalking->Throw();
			pStateMachine->Transition(pStateMachine->pIceWalking);
			break;
		}
		Character::Instance()->GetLocation()->Y = pOnSurface->yFrom - Character::Instance()->GetLocation()->height;
		break;
	}
}