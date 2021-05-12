import {IPlayer, IRootState} from '../types';

export const discussionSelector = (state: IRootState) => state.discussion;

export const voteArraySelector = (state: IRootState) => state.discussion && state.discussion.voteArray;

// const idSelector = (state: IRootState, id: string): string => id;

export const voteByPlayerSelector = (state: IRootState, player: IPlayer) => {
  const voteArray = voteArraySelector(state);
  return voteArray && player && voteArray[player.id];
};
