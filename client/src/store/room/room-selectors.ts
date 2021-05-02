import {IRootState} from '../types';
import {createSelector} from 'reselect';

export const roomsSelector = (state: IRootState) => state.rooms;

const idSelector = (state: IRootState, id: string): string => id;

export const roomByIdSelector = createSelector([roomsSelector, idSelector], (rooms, id) => {
  const index = rooms.findIndex((r) => r.id === id);
  return rooms[index];
});
