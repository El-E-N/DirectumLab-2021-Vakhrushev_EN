import {IUser} from '../types';
import {IUserAction, IRemoveUserAction} from './user-action-creators';
import {ActionType} from '../reducer';

const initState = {
  id: 'test_user',
  name: 'Tester',
};

// eslint-disable-next-line no-unused-vars
export const reducer = (state: IUser | null = initState, action: IUserAction): IUser | null => {
  switch (action.type) {
    case ActionType.CREATE_USER:
      return {id: action.id, name: action.name};
    default:
      return state;
  }
};

export const removeReducer = (state: IUser | null, action: IRemoveUserAction): IUser | null => {
  switch (action.type) {
    case ActionType.REMOVE_USER:
      return null;
    default:
      return state;
  }
};

export const usersReducer = (state: Array<IUser> = [], action: IUserAction): Array<IUser> => {
  switch (action.type) {
    case ActionType.NEW_USER:
      return [...state, {id: action.id, name: action.name}];
    default:
      return state;
  }
};
