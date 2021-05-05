import {IRoom} from '../types';
import {ICardAction, IRoomAction, IAddUserAction} from './room-action-creators';
import {ActionType} from '../reducer';

export function reducer(state: IRoom | null = null, action: ICardAction | IRoomAction | IAddUserAction): IRoom | null {
  switch (action.type) {
    case ActionType.ADD_SELECTED_CARD:
      const voteAction = action as ICardAction;
      return state && {
        ...state,
        selectedCard: voteAction.value,
      };
    case ActionType.CREATE_ROOM:
      const roomAction = action as IRoomAction;
      return roomAction.room;
    case ActionType.ADD_USER_INTO_ROOM:
      const addUserAction = action as IAddUserAction;
      return state && {
        ...state,
        users: [...state.users, addUserAction.user],
      };
    default:
      return state;
  }
}
