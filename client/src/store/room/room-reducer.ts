import {IRoom} from '../types';
import {IRoomAction, IAddUserAction, IUpdateSelectedCardAction} from './room-action-creators';
import {ActionType} from '../reducer';

export function reducer(state: IRoom | null = null, action: IRoomAction | IAddUserAction | IUpdateSelectedCardAction):
    IRoom | null {
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
    case ActionType.UPDATE_SELECTED_CARD:
      const updateAction = action as IUpdateSelectedCardAction;
      return state && {
        ...state,
        selectedCard: updateAction.selectedCard,
      };
    default:
      return state;
  }
}
