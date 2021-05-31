import {IDiscussionDto, IVoteDto, baseUrl, options} from './api-utils';

const discussionUrl = `${baseUrl}/discussion`;

export const createDiscussionRequest = async (
    roomId: string,
    name: string,
): Promise<IDiscussionDto> => {
  const response = await fetch(
      `${discussionUrl}/create?roomId=${roomId}&name=${name}`,
      options.GET);
  return response.json();
};

export const closeDiscussionRequest = async (
    discussionId: string,
): Promise<IDiscussionDto> => {
  const response = await fetch(
      `${discussionUrl}/close?discussionId=${discussionId}`,
      options.GET);
  return response.json();
};

export const setDiscussionNameRequest = async (
  discussionId: string,
  name: string
): Promise<IDiscussionDto> => {
const response = await fetch(
    `${discussionUrl}/setName?discussionId=${discussionId}&name=${name}`,
    options.GET);
return response.json();
};

export const addVoteRequest = async (
    discussionId: string,
    voteId: string
): Promise<IDiscussionDto> => {
  const response = await fetch(
      `${discussionUrl}/addVote?discussionId=${discussionId}&voteId=${voteId}`,
      options.GET);
  return response.json();
};

export const getDiscussionsByRoomIdRequest = async (
  roomId: string,
): Promise<Array<IDiscussionDto>> => {
  const response = await fetch(
    `${discussionUrl}/getDiscussionsByRoomId?roomId=${roomId}`,
    options.GET);
  return response.json();
};

export const getAllVoteRequest = async (
    discussionId: string,
): Promise<Array<IVoteDto>> => {
  const response = await fetch(
      `${discussionUrl}/getAllVote?discussionId=${discussionId}`,
      options.GET);
  return response.json();
};
