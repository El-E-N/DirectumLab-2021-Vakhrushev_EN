import * as React from 'react';
import ResultWithModal from '../result-with-modal/result-with-modal';
import ResultEnterStory from '../result-enter-story/result-enter-story';
import Result from '../result/result';
import Invite from '../invite/invite';
import Planning from '../planning/planning';
import First from '../first/first';

const PageMap: { [key: string]: React.ReactElement } = {
  '1': <First/>,
  '2': <Invite/>,
  '3': <Planning/>,
  '4': <Result/>,
  '5': <ResultEnterStory/>,
  '6': <ResultWithModal/>
};

const App: React.FunctionComponent = () => {
  const [page] = React.useState(6);
  return PageMap[`${page}`];
};

export default App;
