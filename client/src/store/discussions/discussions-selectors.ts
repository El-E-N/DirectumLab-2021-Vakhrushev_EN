import {IDiscussion, IRootState, IPlayer} from '../types';

export const discussionsSelector = (state: IRootState) => state.discussions;

export const discussionByIdSelector = (discussionId: string, discussions: Array<IDiscussion>) => {
  return discussions.find((discussion) => discussion.id = discussionId);
};

export const voteArraySelector = (discussion: IDiscussion) => discussion.voteArray;

export const voteByPlayerSelector = (discussion: IDiscussion, player: IPlayer) => {
  const voteArray = voteArraySelector(discussion);
  return voteArray[player.id];
};
