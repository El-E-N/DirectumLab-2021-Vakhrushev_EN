export interface IRoomDto {
  id: string;
  hash: string;
  name: string;
  players: Array<IPlayerDto>;
  hostId: string;
  creatorId: string;
}

export interface IPlayerDto {
  id: string;
  name: string;
}

export interface IDiscussionDto {
  id: string;
  name: string;
  voteArray: Array<IVoteDto>;
}

export interface IVoteDto {
  id: string;
  playerId: string;
  card: ICardDto;
}

interface ICardDto {
  id: string;
  value: string;
  name: string;
}
