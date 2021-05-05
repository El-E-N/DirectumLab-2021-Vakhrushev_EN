import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IRoom, IUser} from '../types';

export interface ICardAction extends Action {
  value: string;
}

export const updateVote = (roomId: string, value: string): ICardAction => {
  return {
    type: ActionType.ADD_SELECTED_CARD,
    value,
  };
};

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
  user: IUser;
}

export const addUser = (ourRoom: IRoom, user: IUser): IAddUserAction => {
  return {
    type: ActionType.ADD_USER_INTO_ROOM,
    user
  };
};
