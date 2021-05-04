import {IUser} from '../types';
import {IUserAction, IRemoveUserAction} from './user-action-creators';
import {ActionType} from '../reducer';

export const reducer = (state: IUser | null = null, action: IUserAction | IRemoveUserAction): IUser | null => {
  switch (action.type) {
    case ActionType.CREATE_USER:
      const userAction = action as IUserAction;
      return {id: userAction.id, name: userAction.name};
    case ActionType.REMOVE_USER:
      return null;
    default:
      return state;
  }
};
