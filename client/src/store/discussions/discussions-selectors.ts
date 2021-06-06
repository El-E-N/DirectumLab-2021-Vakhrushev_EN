import {IDiscussion, IRootState, IPlayer} from '../types';

export const discussionsSelector = (state: IRootState) => state.discussions;

export const discussionByIdSelector = (discussionId: string, discussions: Array<IDiscussion>): IDiscussion | null => {
  const discussion = discussions.find((discussion) => discussion.id === discussionId);
  return discussion !== undefined ? discussion : null; 
};

export const voteArraySelector = (discussion: IDiscussion) => discussion.voteArray;

export const voteByPlayerSelector = (discussion: IDiscussion, player: IPlayer) => {
  const voteArray = voteArraySelector(discussion);
  const vote = voteArray[player.id];
  return vote;
};
