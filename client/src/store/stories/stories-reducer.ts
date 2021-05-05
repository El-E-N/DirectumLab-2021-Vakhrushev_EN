import {IStory} from '../types';
import {IRemoveStoryAction, IStoryAction, IAddVoteAction} from './stories-action-creators';
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

export function reducer(state: Array<IStory> = initState, action: IRemoveStoryAction | IStoryAction | IAddVoteAction): Array<IStory> {
  switch (action.type) {
    case ActionType.REMOVE_STORY:
      const removeAction = action as IRemoveStoryAction;
      return state.filter((s) => s.id !== removeAction.id);
    case ActionType.ADD_STORY:
      const storyAction = action as IStoryAction;
      return [
        ...state,
        storyAction.story,
      ];
    case ActionType.ADD_VOTE:
      const addVoteAction = action as IAddVoteAction;
      return state.map((story) => {
        if (addVoteAction.id === story.id) {
          story.votes[addVoteAction.userId] = addVoteAction.vote;
          const votes = story.votes;
          return {
            ...story,
            votes,
          };
        }
        return story;
      });
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
