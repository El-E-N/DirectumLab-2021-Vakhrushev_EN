import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IRoom, IPlayer} from '../types';

export interface IRoomAction extends Action {
  room: IRoom;
}

export const createRoom = (room: IRoom): IRoomAction => {
  return {
    type: ActionType.CREATE_ROOM,
    room,
  };
};

export interface IAddUserAction extends Action {
  user: IPlayer;
}

export const addUser = (user: IPlayer): IAddUserAction => {
  return {
    type: ActionType.ADD_USER_INTO_ROOM,
    user
  };
};

export interface IChangeShownModal extends Action {
  shownModal: boolean;
}

export const changeShownModal = (shownModal: boolean): IChangeShownModal => {
  return {
    type: ActionType.CHANGE_SHOWN_MODAL,
    shownModal,
  };
}

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
