import {combineReducers} from 'redux';
import {IRootState} from './types';
import {reducer as roomReducer} from './room/room-reducer';
import {reducer as userReducer, usersReducer} from './user/user-reducer';
import {reducer as storiesReducer} from './stories/stories-reducer';

export const ActionType = {
  VOTE: 'VOTE',
  CREATE_ROOM: 'CREATE_ROOM',
  REMOVE_STORY: 'REMOVE_STORY',
  ADD_STORY: 'ADD_STORY',
  CREATE_USER: 'CREATE_USER',
  REMOVE_USER: 'REMOVE_USER',
  ADD_USER_INTO_ROOM: 'ADD_USER_INTO_ROOM',
  NEW_USER: 'NEW_USER',
};

export const reducer = combineReducers<IRootState>({
  rooms: roomReducer,
  stories: storiesReducer,
  user: userReducer,
  users: usersReducer,
});
