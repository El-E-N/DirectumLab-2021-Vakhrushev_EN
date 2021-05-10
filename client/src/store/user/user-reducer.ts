import {IPlayer} from '../types';
import {IUserAction} from './user-action-creators';
import {ActionType} from '../reducer';

export const reducer = (state: IPlayer | null = null, action: IUserAction): IPlayer | null => {
  switch (action.type) {
    case ActionType.UPDATE_USER:
      return action.user;
    default:
      return state;
  }
};
