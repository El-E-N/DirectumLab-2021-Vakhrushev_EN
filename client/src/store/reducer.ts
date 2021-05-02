import {combineReducers} from 'redux';
import {IRootState} from './types';
import {reducer as roomReducer, createReducer as createRoomReducer, addUserReducer as addUserIntoRoomReducer} from './room/room-reducer';
import {reducer as userReducer, removeReducer as removeUserReducer, usersReducer} from './user/user-reducer';
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
  rooms: roomReducer || createRoomReducer || addUserIntoRoomReducer,
  stories: storiesReducer,
  user: userReducer || removeUserReducer,
  users: usersReducer,
});
