import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IRoom} from '../types';

export interface IRoomAction extends Action {
  room: IRoom | null;
}

export const updateRoom = (room: IRoom | null): IRoomAction => {
  return {
    type: ActionType.CREATE_ROOM,
    room,
  };
};

export interface IAddCurrentDiscussionIdAction extends Action {
  currentDiscussionId: string;
}

export const addCurrentDiscussionId = (currentDiscussionId: string): IAddCurrentDiscussionIdAction => {
  return {
    type: ActionType.ADD_CURRENT_DISCUSSION_ID,
    currentDiscussionId
  };
}

export interface IChangeChoosedDiscussionAction extends Action {
  choosedDiscussionId: string | null;
}

export const changeChoosedDiscussion = (choosedDiscussionId: string | null) => {
  return {
    type: ActionType.CHANGE_CHOOSED_DISCUSSION_ID,
    choosedDiscussionId,
  }
}
