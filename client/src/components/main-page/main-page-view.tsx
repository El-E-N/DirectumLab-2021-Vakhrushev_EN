import * as React from 'react';
import Deck from '../deck/deck';
import Results from '../results/results';
import {RouteComponentProps} from 'react-router-dom';
import Menu from '../menu/menu';
import {RoutePath} from '../../routes';
import {IRoom, IUser} from '../../store/types';
import './main-page.css';

export interface IMatchParams {
  id: string;
}

export interface IMainPageProps extends RouteComponentProps<IMatchParams> {
  room: IRoom;
  user: IUser;
  onShowModal(): void;
  // eslint-disable-next-line no-unused-vars
  vote(roomId: string, value: string): void;
  // eslint-disable-next-line no-unused-vars
  removeStory(id: string): void;
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
    if (this.props.room === undefined) {
      this.props.history.push('/error-nonexistent-room');
      return null;
    } else {
      return <main className="room">
        <h2 className="room-name">{this.props.room.name}</h2>
        <div className="room-content">
          {this.state.isPlanning ?
            <Deck id={this.props.match.params.id}/> :
            <Results onShowModal={this.props.onShowModal}/>}
          <Menu
            addEnter={!this.state.isPlanning}
            onClick={this.handleClick}
          />
        </div>
      </main>;
    }
  }

  componentDidMount() {
    this.props.user === null && this.props.room && this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.id}`);
  }
}

export default MainPageView;
