import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IPlayer} from '../types';

export interface IUserAction extends Action {
  user: IPlayer | null;
}

export const updateUser = (user: IPlayer | null): IUserAction => {
  return {
    type: ActionType.UPDATE_USER,
    user,
  };
};
