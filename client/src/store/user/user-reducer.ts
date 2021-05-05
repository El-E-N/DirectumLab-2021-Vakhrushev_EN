import {IUser} from '../types';
import {IUserAction} from './user-action-creators';
import {ActionType} from '../reducer';

export const reducer = (state: IUser | null = null, action: IUserAction): IUser | null => {
  switch (action.type) {
    case ActionType.UPDATE_USER:
      return action.user;
    default:
      return state;
  }
};
