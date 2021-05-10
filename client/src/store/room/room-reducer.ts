import {IRoom} from '../types';
import {IRoomAction, IAddUserAction} from './room-action-creators';
import {ActionType} from '../reducer';

export function reducer(state: IRoom | null = null, action: IRoomAction | IAddUserAction): IRoom | null {
  switch (action.type) {
    case ActionType.CREATE_ROOM:
      const roomAction = action as IRoomAction;
      return roomAction.room;
    case ActionType.ADD_USER_INTO_ROOM:
      const addUserAction = action as IAddUserAction;
      return state && {
        ...state,
        players: [...state.players, addUserAction.user],
      };
    default:
      return state;
  }
}
