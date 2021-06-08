import {IRoom} from '../types';
import {IRoomAction, IAddCurrentDiscussionIdAction, IChangeChoosedDiscussionAction} from './room-action-creators';
import {ActionType} from '../reducer';

export function reducer(
  state: IRoom | null = null, 
  action: IRoomAction | IAddCurrentDiscussionIdAction | IChangeChoosedDiscussionAction
): IRoom | null {
  switch (action.type) {
    case ActionType.CREATE_ROOM: {
      const roomAction = action as IRoomAction;

      return roomAction.room;
    }

    case ActionType.ADD_CURRENT_DISCUSSION_ID: {
      const addCurrentDiscussionIdAction = action as IAddCurrentDiscussionIdAction;

      return state ? 
        {
          ...state,
          currentDiscussionId: addCurrentDiscussionIdAction.currentDiscussionId,
        } :
        null;
    }

    case ActionType.CHANGE_CHOOSED_DISCUSSION_ID: {
      const changeChoosedDiscussionAction = action as IChangeChoosedDiscussionAction;

      return state ? 
        {
          ...state,
          choosedDiscussionId: changeChoosedDiscussionAction.choosedDiscussionId
        } :
        null;
    }
    
    default: {
      return state;
    }
  }
}
