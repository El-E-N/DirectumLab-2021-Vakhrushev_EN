import {IRootState, IVote} from '../types';

export const discussionSelector = (state: IRootState) => state.discussion;

export const voteArraySelector = (state: IRootState) => state.discussion && state.discussion.voteArray;

// const idSelector = (state: IRootState, id: string): string => id;

export const voteSelector = (voteArray: { [key: string]: IVote | null }, playerId: string) => {
  return voteArray && voteArray[playerId];
};
