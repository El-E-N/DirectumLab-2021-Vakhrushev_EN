import authService from "../services/auth-service";

export const baseUrl = 'http://localhost:3030/api';

export const get = () => {
  return {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json;charset=utf-8',
      'token': authService.get(),
    }
  }
}

export const post = () => {
  return {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json;charset=utf-8',
      'token': authService.get(),
    }
  }
}

export interface IRoomDto {
  id: string;
  hash: string;
  name: string;
  currentPlayers: Array<IPlayerDtoWithoutToken>;
  roomPlayers: Array<IPlayerDtoWithoutToken>;
  hostId: string;
  creatorId: string;
  cards: Array<ICardDtoWithoutToken>;
  discussions: Array<IDiscussionDtoWithoutToken>;
  token: string;
}

export interface IPlayerDtoWithoutToken {
  id: string;
  name: string;
}

export interface IPlayerDto {
  id: string;
  name: string;
  token: string;
}

export interface IDiscussionDtoWithoutToken {
  id: string;
  name: string;
  voteList: Array<IVoteDto>;
  startAt: string | null;
  endAt: string | null;
}

export interface IDiscussionDto {
  id: string;
  name: string;
  voteList: Array<IVoteDto>;
  startAt: string | null;
  endAt: string | null;
  token: string;
}

export interface IVoteDtoWithoutToken {
  id: string;
  playerId: string;
  discussionId: string;
  card: ICardDto | null;
}

export interface IVoteDto {
  id: string;
  playerId: string;
  discussionId: string;
  card: ICardDto | null;
  token: string;
}

export interface ICardDto {
  id: string;
  value: string | null;
  name: string;
  token: string;
}

export interface ICardDtoWithoutToken {
  id: string;
  value: string | null;
  name: string;
}
