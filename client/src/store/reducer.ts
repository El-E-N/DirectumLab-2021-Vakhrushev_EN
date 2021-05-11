import {combineReducers} from 'redux';
import {IRootState} from './types';
import {reducer as roomReducer} from './room/room-reducer';
import {reducer as userReducer} from './user/user-reducer';
import {reducer as discussionsReducer} from './discussions/discussions-reducer';
import {reducer as discussionReducer} from './discussion/discussion-reducer';

export const ActionType = {
  ADD_USER_INTO_ROOM: 'ADD_USER_INTO_ROOM',
  ADD_DISCUSSION: 'ADD_DISCUSSION',
  ADD_VOTE: 'ADD_VOTE',
  CREATE_ROOM: 'CREATE_ROOM',
  CREATE_DISCUSSION: 'CREATE_DISCUSSION',
  UPDATE_VOTE: 'UPDATE_VOTE',
  UPDATE_USER: 'UPDATE_USER',
  UPDATE_SELECTED_CARD: 'UPDATE_SELECTED_CARD',
  REMOVE_DISCUSSION: 'REMOVE_DISCUSSION',
  GET_VOTE: 'GET_VOTE',
};

export const reducer = combineReducers<IRootState>({
  room: roomReducer,
  discussions: discussionsReducer,
  user: userReducer,
  discussion: discussionReducer
});
