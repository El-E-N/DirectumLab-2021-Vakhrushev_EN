import {IRoom} from '../types';
import {IVoteAction, IRoomAction, IAddUserAction} from './room-action-creators';
import {ActionType} from '../reducer';

const initState = [
  {
    id: '777',
    name: 'First Room',
    cards: ['0', '0.5', '1', '2', '3', '5', '8', '13', '20', '40', '100', '?', '∞', 'coffee'],
    selectedCard: null,
    ownerId: 'test_user',
    usersId: ['test_user'],
  },
];

export function reducer(state: Array<IRoom> = initState, action: IVoteAction): Array<IRoom> {
  switch (action.type) {
    case ActionType.VOTE:
      const voteAction = action as IVoteAction;
      return state.map((r) => {
        if (voteAction.roomId === r.id) {
          return {
            ...r,
            selectedCard: action.value,
          };
        }
        return r;
      });
    default:
      return state;
  }
}

export function createReducer(state: Array<IRoom> = initState, action: IRoomAction): Array<IRoom> {
  switch (action.type) {
    case ActionType.CREATE_ROOM:
      return [...state,
        {
          id: action.id,
          name: action.name,
          cards: action.cards,
          selectedCard: action.selectedCard,
          usersId: [action.ownerId],
          ownerId: action.ownerId
        }];
    default:
      return state;
  }
}

export function addUserReducer(state: Array<IRoom> = initState, action: IAddUserAction): Array<IRoom> {
  switch (action.type) {
    case ActionType.ADD_USER_INTO_ROOM:
      const addUserAction = action as IAddUserAction;
      return state.map((r) => {
        if (addUserAction.roomId === r.id) {
          return {
            ...r,
            usersId: [...r.usersId, addUserAction.userId]
          };
        }
        return r;
      });
    default:
      return state;
  }
}
