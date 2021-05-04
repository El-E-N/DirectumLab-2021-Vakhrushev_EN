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
    users: [{id: 'test_user', name: 'Tester'}],
    storiesId: ['1'],
  },
];

export function reducer(state: Array<IRoom> = initState, action: IVoteAction | IRoomAction | IAddUserAction): Array<IRoom> {
  switch (action.type) {
    case ActionType.VOTE:
      const voteAction = action as IVoteAction;
      return state.map((r) => {
        if (voteAction.roomId === r.id) {
          return {
            ...r,
            selectedCard: voteAction.value,
          };
        }
        return r;
      });
    case ActionType.CREATE_ROOM:
      const roomAction = action as IRoomAction;
      return [...state,
        {
          id: roomAction.id,
          name: roomAction.name,
          cards: roomAction.cards,
          selectedCard: roomAction.selectedCard,
          users: [roomAction.owner],
          ownerId: roomAction.owner.id,
          storiesId: roomAction.storiesId,
        }];
    case ActionType.ADD_USER_INTO_ROOM:
      const addUserAction = action as IAddUserAction;
      return state.map((r) => {
        if (addUserAction.roomId === r.id) {
          return {
            ...r,
            users: [...r.users, addUserAction.user]
          };
        }
        return r;
      });
    default:
      return state;
  }
}
