import {combineReducers} from 'redux';
import {IRootState} from './types';
import {reducer as roomReducer} from './room/room-reducer';
import {reducer as userReducer} from './user/user-reducer';
import {reducer as discussionsReducer} from './discussions/discussions-reducer';

export const ActionType = {
  ADD_USER_INTO_ROOM: 'ADD_USER_INTO_ROOM',
  ADD_DISCUSSION: 'ADD_DISCUSSION',
  ADD_CURRENT_DISCUSSION_ID: 'ADD_CURRENT_DISCUSSION_ID',
  CHANGE_SHOWN_MODAL: 'CHANGE_SHOWN_MODAL',
  CHANGE_CHOOSED_DISCUSSION_ID: 'CHANGE_CHOOSED_DISCUSSION_ID',
  CREATE_ROOM: 'CREATE_ROOM',
  CREATE_DISCUSSION: 'CREATE_DISCUSSION',
  UPDATE_VOTE: 'UPDATE_VOTE',
  UPDATE_USER: 'UPDATE_USER',
  UPDATE_DISCUSSIONS: 'UPDATE_DISCUSSIONS',
  REMOVE_DISCUSSION: 'REMOVE_DISCUSSION',
  GET_VOTE: 'GET_VOTE',
};

export const reducer = combineReducers<IRootState>({
  room: roomReducer,
  discussions: discussionsReducer,
  user: userReducer,
});
