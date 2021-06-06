import {baseUrl, options, IVoteDto} from './api-utils';

const voteApi = `${baseUrl}/vote`;

export const createVoteRequest = async (
    roomId: string,
    playerId: string,
    discussionId: string,
): Promise<IVoteDto> => {
  const response = await fetch(
      `${voteApi}/create?roomId=${roomId}&playerId=${playerId}&discussionId=${discussionId}`,
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

export const deleteVoteRequest = async (
  voteId: string
) => {
  await fetch(
      `${voteApi}/delete?voteId=${voteId}`,
      options.GET);
  };
