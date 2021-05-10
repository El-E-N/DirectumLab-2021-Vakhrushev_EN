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

export const addUser = (ourRoom: IRoom, user: IPlayer): IAddUserAction => {
  return {
    type: ActionType.ADD_USER_INTO_ROOM,
    user
  };
};
