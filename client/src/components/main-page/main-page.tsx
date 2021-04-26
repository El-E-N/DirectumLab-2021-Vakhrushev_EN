import * as React from 'react';
import Deck from '../deck/deck';
import Results from '../results/results';
import {withRouter, RouteComponentProps} from 'react-router-dom';
import Menu from '../menu/menu';
import './main-page.css';

const deck = [
  {value: '0', isChecked: false, onChange() {}},
  {value: '0.5', isChecked: false, onChange() {}},
  {value: '1', isChecked: false, onChange() {}},
  {value: '2', isChecked: false, onChange() {}},
  {value: '3', isChecked: false, onChange() {}},
  {value: '5', isChecked: false, onChange() {}},
  {value: '8', isChecked: false, onChange() {}},
  {value: '13', isChecked: false, onChange() {}},
  {value: '20', isChecked: false, onChange() {}},
  {value: '40', isChecked: false, onChange() {}},
  {value: '100', isChecked: false, onChange() {}},
  {value: '?', isChecked: false, onChange() {}},
  {value: '∞', isChecked: false, onChange() {}},
  {value: 'coffee', isSvg: true, isChecked: false, onChange() {}}
];

interface IMatchParams {
  id: string;
}

interface IProps extends RouteComponentProps<IMatchParams> {
  roomName?: string;
  name?: string;
  onShowModal?(): void;
}

interface IState {
  view: string;
  addEnterStory: boolean;
}

export class MainPage extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      view: 'planning',
      addEnterStory: false,
    };
    this.handleClick = this.handleClick.bind(this);
  }

  public handleClick() {
    this.setState({
      view: 'result',
      addEnterStory: true,
    });
  }

  public render() {
    return <main className="room">
      <h2 className="room-name">{this.props.roomName}</h2>
      <div className="room-content">
        {this.state.view === 'planning' && <Deck values={deck}/>}
        {this.state.view === 'result' && <Results onShowModal={this.props.onShowModal}/>}
        <Menu addEnter={this.state.addEnterStory} onClick={this.handleClick}/>
      </div>
    </main>;
  }
}

export default withRouter(MainPage);
