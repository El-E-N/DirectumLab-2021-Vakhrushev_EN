import * as React from 'react';
import Deck from '../deck/deck';
import {RouteComponentProps} from 'react-router-dom';
import Menu from '../menu/menu';
import {RoutePath} from '../../routes';
import {IRoom, IPlayer, ICard, IVote} from '../../store/types';
import BrieflyResults from '../briefly-results/briefly-results';
import History from '../history/history';
import './main-page.css';

interface IMatchParams {
  hash: string;
}

export interface IMainPageProps extends RouteComponentProps<IMatchParams> {
  room: IRoom | null;
  player: IPlayer | null;
  vote: IVote | null;
  onShowModal(): void;
  // eslint-disable-next-line no-unused-vars
  getRoom(hash: string): IRoom;
  // eslint-disable-next-line no-unused-vars
  updateVote(voteId: string, cardId: string): void;
  // eslint-disable-next-line no-unused-vars
  updateCard(room: IRoom, selectedCard: ICard): void;
  // eslint-disable-next-line no-unused-vars
  getVote(user: IPlayer): IVote | null;
}

interface IState {
  isPlanning: boolean;
}

export class MainPageView extends React.Component<IMainPageProps, IState> {
  constructor(props: IMainPageProps) {
    super(props);
    this.state = {
      isPlanning: true,
    };
    this.handleClick = this.handleClick.bind(this);
  }

  public handleClick() {
    this.setState({
      isPlanning: false,
    });
  }

  public render() {
    return this.props.room === null ?
      null :
      <main className="room">
        <h2 className="room-name">{this.props.room && this.props.room.name}</h2>
        <div className="room-content">
          <div className="results">
            {this.state.isPlanning ?
              <Deck
                room={this.props.room}
                updateVote={this.props.updateVote}
                updateCard={this.props.updateCard}
                vote={this.props.vote}
              /> :
              <BrieflyResults/>}
            <History stories={[]} onShowModal={this.props.onShowModal}/>
          </div>
          <Menu
            addEnter={!this.state.isPlanning}
            onClick={this.handleClick}
            room={this.props.room}
            player={this.props.player}
            getVote={this.props.getVote}
          />
        </div>
      </main>;
  }

  async componentDidMount() {
    if (this.props.player === null) {
      this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.hash}`);
    } else {
      this.props.room === null && await this.props.getRoom(this.props.match.params.hash);
    }
  }
}

export default MainPageView;
