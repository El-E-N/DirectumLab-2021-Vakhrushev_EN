import {IStory} from '../types';
import {IRemoveStoryAction} from './stories-action-creators';
import {ActionType} from '../reducer';

const initState = [
  {
    id: '1',
    name: 'The first story',
    average: 8,
    votes: {
      player1: '8',
      player2: '8',
    },
  },
  {
    id: '2',
    name: 'The second story',
    average: 16,
    votes: {
      player1: '16',
      player2: '16',
    },
  },
];

export function reducer(state: Array<IStory> = initState, action: IRemoveStoryAction): Array<IStory> {
  switch (action.type) {
    case ActionType.REMOVE_STORY:
      return state.filter((s) => s.id !== action.id);
    case 'ADD_STORY':
      return [...state];
    case 'CHANGE_NAME':
      return state.map((s) => {
        if (s.id === 'sdafsag') {
          return {
            ...s,
            name: 'asdgsadg',
          };
        }
        return s;
      });
    default:
      return state;
  }
}
