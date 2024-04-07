namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository influencerRepository;

        [SetUp]
        public void Setup()
        {
            influencerRepository = new InfluencerRepository();
        }

        [Test]
        public void RegisterInfluencer_ValidInfluencer_SuccessfullyAdded()
        {
            var influencer = new Influencer("testUser", 100);

            var result = influencerRepository.RegisterInfluencer(influencer);

            Assert.IsTrue(influencerRepository.Influencers.Any());
            Assert.AreEqual($"Successfully added influencer {influencer.Username} with {influencer.Followers}", result);
        }

        [Test]
        public void RegisterInfluencer_NullInfluencer_ThrowsArgumentNullException()
        {
            Influencer influencer = null;

            Assert.Throws<ArgumentNullException>(() => influencerRepository.RegisterInfluencer(influencer));
        }

        [Test]
        public void RegisterInfluencer_DuplicateUsername_ThrowsInvalidOperationException()
        {
            var influencer = new Influencer("testUser", 100);
            influencerRepository.RegisterInfluencer(influencer);

            Assert.Throws<InvalidOperationException>(() => influencerRepository.RegisterInfluencer(influencer));
        }

        [Test]
        public void RemoveInfluencer_ValidUsername_ReturnsTrue()
        {
            var influencer = new Influencer("testUser", 100);
            influencerRepository.RegisterInfluencer(influencer);

            var result = influencerRepository.RemoveInfluencer("testUser");

            Assert.IsTrue(result);
            Assert.IsEmpty(influencerRepository.Influencers);
        }

        [Test]
        public void RemoveInfluencer_NullOrEmptyUsername_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(null));
            Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(""));
            Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer("   "));
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ValidData_ReturnsInfluencerWithMostFollowers()
        {
            var influencer1 = new Influencer("user1", 200);
            var influencer2 = new Influencer("user2", 300);
            influencerRepository.RegisterInfluencer(influencer1);
            influencerRepository.RegisterInfluencer(influencer2);

            var result = influencerRepository.GetInfluencerWithMostFollowers();

            Assert.AreEqual(influencer2, result);
        }

        [Test]
        public void GetInfluencer_ValidUsername_ReturnsCorrectInfluencer()
        {
            var influencer1 = new Influencer("user1", 200);
            var influencer2 = new Influencer("user2", 300);
            influencerRepository.RegisterInfluencer(influencer1);
            influencerRepository.RegisterInfluencer(influencer2);

            var result = influencerRepository.GetInfluencer("user1");

            Assert.AreEqual(influencer1, result);
        }

        [Test]
        public void GetInfluencer_UnknownUsername_ReturnsNull()
        {
            var influencer1 = new Influencer("user1", 200);
            var influencer2 = new Influencer("user2", 300);
            influencerRepository.RegisterInfluencer(influencer1);
            influencerRepository.RegisterInfluencer(influencer2);

            var result = influencerRepository.GetInfluencer("unknownUser");

            Assert.IsNull(result);
        }
    }
}