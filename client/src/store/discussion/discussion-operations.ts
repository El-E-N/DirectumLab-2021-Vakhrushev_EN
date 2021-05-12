import {Dispatch} from 'redux';
import * as discussionApi from '../../api/discussion-api';
import * as voteApi from '../../api/vote-api';
import {ICard, IDiscussion, IVote} from '../types';
import {createDiscussion as createStoreDiscussion} from './discussion-action-creators';
import {updateVote as updateStoreVote} from './discussion-action-creators';
import {translateDtoCardIntoCard} from '../card';

export const createDiscussion = (roomId: string): any => {
  return async (dispatch: Dispatch) => {
    const discussionDto = await discussionApi.createDiscussionRequest(roomId, '');
    const allVote: { [key: string]: IVote | null } = {};
    const {voteList} = discussionDto;
    for (let i: number = 0; i < voteList.length; i++) {
      const playerId = voteList[i].playerId;
      const translatedCard = translateDtoCardIntoCard(voteList[i].card);
      const card: ICard = {
        id: voteList[i].card.id,
        value: translatedCard.value
      };
      allVote[playerId] = {id: voteList[i].id, card};
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
    const translatedCard = translateDtoCardIntoCard(voteDto.card);
    const card: ICard = {
      id: voteDto.card.id,
      value: translatedCard.value
    };
    dispatch(updateStoreVote(voteDto.id, card));
  };
};
