const app = require("express")();

const PORT = 5000 || process.env.PORT;

app.listen(PORT, () => console.log(`listening on port ${PORT}............`));
