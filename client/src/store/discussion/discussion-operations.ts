import {Dispatch} from 'redux';
import * as discussionApi from '../../api/discussion-api';
import * as voteApi from '../../api/vote-api';
import {ICard, IDiscussion, IVote} from '../types';
import {createDiscussion as createStoreDiscussion} from './discussion-action-creators';
import {updateVote as updateStoreVote} from './discussion-action-creators';
import {translateDtoCardsIntoCard} from '../card';

export const createDiscussion = (roomId: string): any => {
  return async (dispatch: Dispatch) => {
    const discussionDto = await discussionApi.createDiscussionRequest(roomId, '');
    const allVote: { [key: string]: IVote | null } = {};
    const {voteArray} = discussionDto;
    for (let i: number = 0; i < discussionDto.voteArray.length; i++) {
      const playerId = voteArray[i].playerId;
      const cards = translateDtoCardsIntoCard([voteArray[i].card]);
      const card: ICard = {
        id: voteArray[i].card.id,
        value: cards[0].value
      };
      allVote[playerId] = {id: voteArray[i].id, card};
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
    const cards = translateDtoCardsIntoCard([voteDto.card]);
    const card: ICard = {
      id: voteDto.card.id,
      value: cards[0].value
    };
    dispatch(updateStoreVote(voteDto.id, card));
  };
};
