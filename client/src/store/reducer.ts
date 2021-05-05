import {combineReducers} from 'redux';
import {IRootState} from './types';
import {reducer as roomReducer} from './room/room-reducer';
import {reducer as userReducer} from './user/user-reducer';
import {reducer as storiesReducer} from './stories/stories-reducer';

export const ActionType = {
  ADD_SELECTED_CARD: 'ADD_SELECTED_CARD',
  CREATE_ROOM: 'CREATE_ROOM',
  REMOVE_STORY: 'REMOVE_STORY',
  ADD_STORY: 'ADD_STORY',
  UPDATE_USER: 'UPDATE_USER',
  ADD_USER_INTO_ROOM: 'ADD_USER_INTO_ROOM',
  ADD_VOTE: 'ADD_VOTE',
};

export const reducer = combineReducers<IRootState>({
  room: roomReducer,
  stories: storiesReducer,
  user: userReducer,
});
