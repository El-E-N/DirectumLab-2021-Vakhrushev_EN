export interface IPlayer {
  id: string;
  name: string;
}

export interface IRoom {
  id: string;
  hash: string;
  name: string;
  cards: Array<ICard>;
  selectedCard: ICard | null;
  hostId: string;
  creatorId: string;
  players: Array<IPlayer>;
}

export interface IDiscussion {
  id: string;
  name: string | null;
  average: number | null;
  voteArray: { [key: string]: IVote | null }; // key - userId, value - vote
}

export interface IVote {
  id: string;
  card: ICard;
}

export interface ICard {
  id: string;
  value: string;
}

export interface IRootState {
  room: IRoom | null;
  discussions: Array<IDiscussion> | null;
  discussion: IDiscussion | null;
  user: IPlayer | null;
}
