import {baseUrl, options, IVoteDto} from './api-utils';

const voteApi = `${baseUrl}/vote`;

export const createVoteRequest = async (
    cardId: string,
    roomId: string,
    playerId: string,
    discussionId: string,
): Promise<IVoteDto> => {
  const response = await fetch(
      `${voteApi}/create?cardId=${cardId}&roomId=${roomId}&playerId=${playerId}&discussionId=${discussionId}`,
      options.GET);
  return response.json();
};

export const changeCardRequest = async (
    voteId: string,
    cardId: string,
): Promise<IVoteDto> => {
  const response = await fetch(
      `${voteApi}/changeCard?voteId=${voteId}&cardId=${cardId}`,
      options.GET);
  return response.json();
};
