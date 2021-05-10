import {Dispatch} from 'redux';
import * as discussionApi from '../../api/discussion-api';
import * as voteApi from '../../api/vote-api';
import {IDiscussion, IVote} from '../types';
import {createDiscussion as createStoreDiscussion} from './discussion-action-creators';
import {updateVote as updateStoreVote} from './discussion-action-creators';

export const createDiscussion = (roomId: string): any => {
  return async (dispatch: Dispatch) => {
    const discussionDto = await discussionApi.createDiscussionRequest(roomId, '');
    const allVote: { [key: string]: IVote | null } = {};
    const {voteArray} = discussionDto;
    for (let i: number = 0; i < discussionDto.voteArray.length; i++) {
      const playerId = voteArray[i].playerId;
      allVote[playerId] = {id: voteArray[i].id, card: voteArray[i].card};
    }
    const discussion: IDiscussion = {
      ...discussionDto,
      average: null,
      voteArray: allVote,
    };
    dispatch(createStoreDiscussion(discussion));
  };
};

export const updateVote = (voteId: string, cardId: string): any => {
  return async (dispatch: Dispatch) => {
    const voteDto = await voteApi.changeCardRequest(voteId, cardId);
    dispatch(updateStoreVote(voteDto.id, voteDto.card));
  };
};
