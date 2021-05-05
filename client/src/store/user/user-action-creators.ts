import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IUser} from '../types';

export interface IUserAction extends Action {
  user: IUser | null;
}

export const updateUser = (user: IUser | null): IUserAction => {
  return {
    type: ActionType.UPDATE_USER,
    user,
  };
};
