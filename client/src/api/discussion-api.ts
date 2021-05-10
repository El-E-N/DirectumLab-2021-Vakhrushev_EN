import {IDiscussionDto, IVoteDto} from './types';
import {baseUrl, options} from './api';

export const createDiscussionRequest = async (
    roomId: string,
    name: string,
): Promise<IDiscussionDto> => {
  const response = await fetch(
      `${baseUrl}/discussion/create?roomId=${roomId}&name=${name}`,
      options.GET);
  return response.json();
};

export const closeDiscussionRequest = async (
    discussionId: string,
): Promise<IDiscussionDto> => {
  const response = await fetch(
      `${baseUrl}/discussion/close?discussionId=${discussionId}`,
      options.GET);
  return response.json();
};

export const addVoteRequest = async (
    discussionId: string,
    voteId: string
): Promise<IDiscussionDto> => {
  const response = await fetch(
      `${baseUrl}/discussion/addVote?discussionId=${discussionId}&voteId=${voteId}`,
      options.GET);
  return response.json();
};

export const getAllVoteRequest = async (
    discussionId: string,
): Promise<Array<IVoteDto>> => {
  const response = await fetch(
      `${baseUrl}/discussion/getAllVote?discussionId=${discussionId}`,
      options.GET);
  return response.json();
};
