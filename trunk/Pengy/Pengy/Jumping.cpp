#include "Jumping.h"
#include "Character.h"

Jumping::Jumping(void)
{
	this->upwardVelocity = 0;
	this->speed = 0.3f;
}

Jumping::Jumping(CharacterStateMachine * pStateMachine) : CharacterState(pStateMachine)
{
	this->upwardVelocity = 0;
	this->speed = 0.3f;
}

void Jumping::Up()
{

}

void Jumping::Down()
{
	
}


void Jumping::Left()
{
	if(this->direction != Direction::Left)
	{
		Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::JumpLeft);
	}
	this->direction = Direction::Left;
	this->distanceToMove = 5;
}


void Jumping::Right()
{
	if(this->direction != Direction::Right) 
	{
		Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::JumpRight);
	}
	this->direction = Direction::Right;
	this->distanceToMove = 5;
}

void Jumping::Throw()
{

}


void Jumping::Spacebar()
{
	if(Character::Instance()->getDirection() == Direction::Right)
	{
		Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::JumpRight);
	}
	else {
		Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::JumpLeft);
	}
	
	if(upwardVelocity == 0)
	{
		upwardVelocity = 0.160;
	}
}

void Jumping::Update(int timeElapsed)
{
	Location * oldLocation = Character::Instance()->GetLocation();
	Location * newLocation = new Location();
	newLocation->X = oldLocation->X;
	newLocation->Y = oldLocation->Y;
	newLocation->width = oldLocation->width;
	newLocation->height = oldLocation->height;

	if(upwardVelocity > 0)
	{
		float y = newLocation->Y;
		float newUpwardVelocity = upwardVelocity  - (0.000120 * timeElapsed);
		float averageVelocity = (upwardVelocity + newUpwardVelocity) / 2;
		float distance = averageVelocity * timeElapsed;
		newLocation->Y -= distance;
		upwardVelocity = newUpwardVelocity;

		float distanceMoved = timeElapsed * this->speed;
		if(distanceMoved > this->distanceToMove) distanceMoved = distanceToMove;
		this->distanceToMove -= distanceMoved;

		switch(this->direction)
		{
		case Direction::Left:
			newLocation->X -= distanceMoved;
			break;
		case Direction::Right:
			newLocation->X += distanceMoved;
			break;
		}
		Character::Instance()->SetLocation(newLocation);
		MessageQueue::Inst()->sendMessage(CM_CHARACTER_JUMP_Y_FROM_TO, (int)oldLocation, (int)newLocation);
		MessageQueue::Inst()->sendMessage(CM_CHARACTER_MOVE_X_FROM_TO, (int)oldLocation, (int)newLocation);
	}	
	else
	{
		upwardVelocity = 0;
		this->pStateMachine->Transition(this->pStateMachine->falling);
		if(Character::Instance()->getDirection() == Direction::Right)
		{
			Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::FallingRight);
		}
		else {
			Character::Instance()->GetCharacterView()->ChangeCurrentImage(CharacterView::CharacterImage::FallingLeft);
		}
	}
}

void Jumping::recieveMessage(UINT message, WPARAM wParam, LPARAM lParam)
{
	Surface * surface;
	switch(message)
	{
	case CM_CHARACTER_JUMPING_BUMPS_HEAD:
		surface = (Surface*)wParam;
		Character::Instance()->GetLocation()->Y = surface->yTo;
		this->pStateMachine->Transition(this->pStateMachine->falling);
		break;
	case CM_CHARACTER_BUMPS_INTO:
		surface = (Surface*)wParam;
		if(Character::Instance()->getDirection() == Direction::Right)
		{
			Character::Instance()->GetLocation()->X = surface->xFrom - Character::Instance()->GetLocation()->width;
		}
		else
		{
			Character::Instance()->GetLocation()->X = surface->xTo;
		}
		break;
	}
}