#include "MessageQueue.h"
#include "Observer.h"

MessageQueue* MessageQueue::pInstance = NULL;

MessageQueue* MessageQueue::Inst(){
  if(pInstance == NULL){
    pInstance = new MessageQueue();
  }
  return pInstance;
}

MessageQueue::MessageQueue(){ 
}

MessageQueue::~MessageQueue(){
  if(pInstance != 0)delete pInstance;
}

void MessageQueue::attach( Observer *myObserver)
{
    myObs.push_back( myObserver);
}

void MessageQueue::detach( Observer *myObserver)
{
    for (unsigned int i= 0; i< myObs.size(); i++)
    {
        if (myObs[i]== myObserver)
        {
            myObs.erase(myObs.begin()+i);
            return;
        }
    }
}

void MessageQueue::sendMessage(UINT message, WPARAM wParam, LPARAM lParam)
{
    for (unsigned int i= 0; i< myObs.size(); i++)
    {
        myObs[i]->recieveMessage(message, wParam, lParam);
    }
}