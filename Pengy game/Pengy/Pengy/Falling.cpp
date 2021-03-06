#include "Falling.h"
#include "Character.h"
#include "Surface.h"
#include "Sliding.h"

Falling::Falling(void)
{
	this->distanceToMove = 0;
	this->downwardVelocity = 0;
	this->speed = 0.18f;
}

Falling::Falling(CharacterStateMachine * pStateMachine) : CharacterState(pStateMachine)
{
	this->distanceToMove = 0;
	this->downwardVelocity = 0;
	this->speed = 0.18f;
}

void Falling::Up()
{

}

void Falling::Down()
{
	if(Character::Instance()->GetDirection() == Direction::Right) 
	{
		Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::FallingRight);
	}
	else
	{
		Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::FallingLeft);
	}
}


void Falling::Left()
{
	if(Character::Instance()->GetDirection() != Direction::Left)
	{
		Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::FallingLeft);
	}
	Character::Instance()->SetDirection(Direction::Left);
	this->distanceToMove = 5;
}


void Falling::Right()
{
	if(Character::Instance()->GetDirection() != Direction::Right) 
	{
		Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::FallingRight);
	}
	Character::Instance()->SetDirection(Direction::Right);
	this->distanceToMove = 5;
}

void Falling::Throw()
{

}


void Falling::Spacebar()
{

}

void Falling::Update(int timeElapsed)
{
	float distanceMoved = timeElapsed * this->speed;
	if(distanceMoved > this->distanceToMove) distanceMoved = distanceToMove;
	this->distanceToMove -= distanceMoved;
	Location * pOldLocation = Character::Instance()->GetLocation();
	Location * pNewLocation = new Location();
	pNewLocation->X = pOldLocation->X;
	pNewLocation->Y = pOldLocation->Y;
	pNewLocation->width = pOldLocation->width;
	pNewLocation->height = pOldLocation->height;

	switch(Character::Instance()->GetDirection())
	{
	case Direction::Left:
		pNewLocation->X -= distanceMoved;
		break;
	case Direction::Right:
		pNewLocation->X += distanceMoved;
		break;
	}

	float newDownwardVelocity = (float)(downwardVelocity + (0.000400 * timeElapsed));
	float averageVelocity = (downwardVelocity + newDownwardVelocity) / 2;
	averageVelocity = min(averageVelocity, 0.525);
	float distance = averageVelocity * timeElapsed;
	Character::Instance()->GetLocation()->Y += distance;
	float newCharacterLocation = Character::Instance()->GetLocation()->Y + distance;
	downwardVelocity = newDownwardVelocity;
	pNewLocation->Y += distance;
	Character::Instance()->SetLocation(pNewLocation);
	MessageQueue::Instance()->SendMessage(CM_CHARACTER_MOVE_X_FROM_TO, (int)pOldLocation, (int)pNewLocation);
	MessageQueue::Instance()->SendMessage(CM_CHARACTER_FALL_Y_FROM_TO, (int)pOldLocation, (int)pNewLocation);
}

void Falling::ReceiveMessage(UINT message, WPARAM wParam, LPARAM lParam)
{
	Surface * pSurface;
	Location * pCharacterLocation;
	switch(message)
	{
	case CM_CHARACTER_IS_STANDING:
		downwardVelocity = 0;
		pSurface = (Surface*)wParam;
		if(pSurface->isSurfaceOfDeath)
		{
			MessageQueue::Instance()->SendMessage(CM_CHARACTER_KILLED, NULL, NULL);
			break;
		}
		if(pSurface->isSlope != 0)
		{
			vector<Surface*> * slopes = (vector<Surface*>*) lParam;
			Sliding * sliding = (Sliding*)pStateMachine->pSliding;
			sliding->SetSlopes(slopes);
			pStateMachine->Transition(pStateMachine->pSliding);
			break;
		}
		if(pSurface->isIce == true && Character::Instance()->hasSnowBoots == false)
		{
			MessageQueue::Instance()->SendMessage(CM_SOUND_EVENT,(WPARAM)(LPCTSTR)"res/Waves/smash.wav", 0);
			pStateMachine->pIceWalking->Throw();
			if(Character::Instance()->GetDirection() != Direction::Right) 
				Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::Left);
			else 
				Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::Right);
			pStateMachine->Transition(pStateMachine->pIceWalking);
			break;
		}
		pCharacterLocation = Character::Instance()->GetLocation();
		pCharacterLocation->Y = pSurface->yFrom - pCharacterLocation->height;
		Character::Instance()->SetLocation(pCharacterLocation);
		this->pStateMachine->Transition(this->pStateMachine->pIdle);
		if(Character::Instance()->GetDirection() == Direction::Right)
		{
			Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::Right);
		}
		else {
			Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::Left);
		}
		break;
	case CM_CHARACTER_BUMPS_INTO:
		Surface * pSurface = (Surface*)wParam;
		if(((Character::Instance()->GetLocation()->X + Character::Instance()->GetLocation()->width) >= pSurface->xFrom) && pSurface->xTo > (Character::Instance()->GetLocation()->X + Character::Instance()->GetLocation()->width))
		{
			Character::Instance()->GetLocation()->X = pSurface->xFrom - Character::Instance()->GetLocation()->width;
		}
		else
		{
			Character::Instance()->GetLocation()->X = (float)pSurface->xTo;
		}
		break;
	}
}