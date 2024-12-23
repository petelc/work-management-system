export default function BoardTable({ boards }) {
  return (
    <div>
      <h1>Board Table</h1>
      <table>
        <thead>
          <tr>
            <th>Board ID</th>
            <th>Board Name</th>
            <th>Board Description</th>
          </tr>
        </thead>
        <tbody>
          {boards.map((board) => (
            <tr key={board.boardId}>
              <td>{board.boardId}</td>
              <td>{board.boardName}</td>
              <td>{board.boardDescription}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
