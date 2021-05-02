import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IUser} from '../types';

export interface IUserAction extends Action {
  id: string;
  name: string;
}

export const user = (id: string, name: string): IUserAction => {
  return {
    type: ActionType.CREATE_USER,
    id,
    name,
  };
};

export const newUser = (id: string, name: string): IUserAction => {
  return {
    type: ActionType.NEW_USER,
    id,
    name,
  };
};

export interface IRemoveUserAction extends Action {
  user: IUser | null;
}

export const removeUser = (): IRemoveUserAction => {
  return {
    type: ActionType.CREATE_USER,
    user: null,
  };
};
